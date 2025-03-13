﻿using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.MessageDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            List<Message> messages = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessage)
        {
            Message message = _mapper.Map<Message>(createMessage);
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Mesaj Ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessage)
        {
            Message message = _mapper.Map<Message>(updateMessage);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Mesaj Güncelleme işlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            Message message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            Message message = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(message));
        }
    }
}
