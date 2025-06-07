using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContactController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAllContacts()
        {
            var result = await _unitOfWork.Contacts.GetAllAsync();
            return _mapper.Map<List<ContactDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactDto>> GetContactById(int id)
        {
            var result = await _unitOfWork.Contacts.GetByIdAsync(id);
            return _mapper.Map<ContactDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contact>> Post(CreateContactDto resultDto)
        {
            var result = _mapper.Map<Contact>(resultDto);
            this._unitOfWork.Contacts.Add(result);
            await _unitOfWork.SaveAsync();
            if (result == null)
            {
                return BadRequest();
            }
            var readResultDto = _mapper.Map<ContactDto>(result);
            return CreatedAtAction(nameof(Post), new { id = readResultDto.Id }, resultDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contact>> Put(int id, [FromBody] ContactDto resultDto)
        {
            var result = _mapper.Map<Contact>(resultDto);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Contacts.Update(result);
            await _unitOfWork.SaveAsync();
            return result;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteContactById(int id)
        {
            var result = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Contacts.Remove(result);
            await _unitOfWork.SaveAsync();
            return Ok(new { message = "Eliminado satisfactoriamente" });
        }
    }
}
