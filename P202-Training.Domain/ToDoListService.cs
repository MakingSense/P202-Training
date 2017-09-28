using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using P202.Training.Data.Repositories;
using AutoMapper;
using P202.Training.Domain.Models;

namespace P202.Training.Domain
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IMapper _mapper;

        public ToDoListService(IToDoListRepository toDoListRepository, IMapper mapper)
        {
            _toDoListRepository = toDoListRepository;
            _mapper = mapper;
        }

        public void CreateToDoList(ToDoList toDoList)
        {
            if (toDoList == null) return;
            var mapToDoList = _mapper.Map<Data.Entities.ToDoList>(toDoList);
            _toDoListRepository.CreateToDoList(mapToDoList);
        }

        public void DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteToDoList(id);
        }

        public IList<ToDoList> ListToDoList()
        {
            var listToDoList = _toDoListRepository.GetAllToDoList();
            var mapToDoList = _mapper.Map<IList<ToDoList>>(listToDoList);
            return mapToDoList;
        }

        public ToDoList ReadToDoList(int id)
        {
            var listToDoList = _toDoListRepository.GetToDoList(id);
            var mapToDoListResp = _mapper.Map<ToDoList>(listToDoList);
            return mapToDoListResp;
        }

        public ToDoList UpdateToDoList(ToDoList toDoList)
        {
            if (toDoList == null) return toDoList;
            var mapToDoList = _mapper.Map<Data.Entities.ToDoList>(toDoList);
            var respUpdateToDoList = _toDoListRepository.UpdateToDoList(mapToDoList);
            var unmapToDoList = _mapper.Map<ToDoList>(respUpdateToDoList);
            return unmapToDoList;
        }
    }
}
