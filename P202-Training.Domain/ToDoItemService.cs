using AutoMapper;
using P202.Training.Data.Repositories;
using P202.Training.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P202.Training.Domain
{
    public class ToDoItemService: IToDoItemService
    {


        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IMapper _mapper;

        public ToDoItemService(IToDoItemRepository ToDoItemRepository, IMapper mapper)
        {
            _toDoItemRepository = ToDoItemRepository;
            _mapper = mapper;
        }

        public void CreateToDoItem(ToDoItem toDoItem)
        {
            if (toDoItem == null) return;
            var mapToDoItem = _mapper.Map<Data.Entities.ToDoItem>(toDoItem);
            _toDoItemRepository.CreateToDoItem(mapToDoItem);
        }

        public void DeleteToDoItem(int id)
        {
            _toDoItemRepository.DeleteToDoItem(id);
        }

        public IList<ToDoItem> ListToDoItem()
        {
            var listToDoItem = _toDoItemRepository.GetAllToDoItem();
            var mapToDoItem = _mapper.Map<IList<ToDoItem>>(listToDoItem);
            return mapToDoItem;
        }

        public ToDoItem ReadToDoItem(int id)
        {
            var listToDoItem = _toDoItemRepository.GetToDoItem(id);
            var mapToDoItemResp = _mapper.Map<ToDoItem>(listToDoItem);
            return mapToDoItemResp;
        }

        public ToDoItem UpdateToDoItem(ToDoItem toDoItem)
        {
            if (toDoItem == null) return toDoItem;
            var mapToDoItem = _mapper.Map<Data.Entities.ToDoItem>(toDoItem);
            var respUpdateToDoItem = _toDoItemRepository.UpdateToDoItem(mapToDoItem);
            var unmapToDoItem = _mapper.Map<ToDoItem>(respUpdateToDoItem);
            return unmapToDoItem;
        }
    }
}
