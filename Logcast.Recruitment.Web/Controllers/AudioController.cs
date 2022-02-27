using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Logcast.Recruitment.Application.UseCases.AudioFileMetadatas;
using Logcast.Recruitment.Application.UseCases.AudioFileMetadatas.Models;
using Logcast.Recruitment.Application.UseCases.AudioFiles;
using Logcast.Recruitment.Application.UseCases.AudioFiles.Models;
using Logcast.Recruitment.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Logcast.Recruitment.Web.Controllers
{
    [ApiController]
    [Route("api/audio")]
    public class AudioController : ControllerBase
    {
        private readonly IAudioFileService _audioFileService;
        private readonly IAudioFileMetadataService _audioFileMetadataService;

        public AudioController(IAudioFileService audioFileService,
                               IAudioFileMetadataService audioFileMetadataService)
        {
            _audioFileService = audioFileService;
            _audioFileMetadataService = audioFileMetadataService;
        }

        [HttpPost("audio-file")]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio file uploaded successfully", typeof(HttpResponse))]
        [ProducesResponseType(typeof(HttpResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadAudioFile(IFormFile audioFile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!audioFile.ContentType.Equals("audio/mpeg", StringComparison.OrdinalIgnoreCase))
                return BadRequest();

            try
            {
                if (audioFile.Length > 0)
                {
                    var filePath = await FileUploader.UploadFile(audioFile);
                    await _audioFileService.UploadFile(new AudioFileUploadModel
                    {
                        Name = audioFile.FileName,
                        Size = audioFile.Length,
                        ContentType = audioFile.ContentType,
                        FilePath = filePath
                    });
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio metadata registered successfully")]
        public async Task<IActionResult> AddAudioMetadata([Required][FromBody] SaveAudioMetaDataModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (await _audioFileService.ExistsAsync(request.AudioFileId))
                {
                    await _audioFileMetadataService.FetchMetadataAsync(request);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{audioId:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio metadata fetched successfully", typeof(AudioFileModel))]
        [ProducesResponseType(typeof(AudioFileModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAudioMetadata([FromRoute] Guid audioId)
        {
            var audioFile = await _audioFileService.GetAsync(audioId);
            return Ok(audioFile);
        }

        [HttpGet("stream/{audioId:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Preview stream started successfully", typeof(FileContentResult))]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAudioStream([FromRoute] Guid audioId)
        {
            var audioFile = await _audioFileService.GetAsync(audioId);
            var buffer = await System.IO.File.ReadAllBytesAsync(audioFile.Path);
            return File(new MemoryStream(buffer), "audio/mpeg");
        }
    }
}