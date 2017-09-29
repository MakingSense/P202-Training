using System.Collections.Generic;
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

        public ToDoList CreateToDoList(ToDoList toDoList)
        {
            if (toDoList == null)
                return null;
            var mapToDoItem = _mapper.Map<Data.Entities.ToDoList>(toDoList);
            return _mapper.Map<Models.ToDoList>(_toDoListRepository.Create(mapToDoItem));
        }

        public void DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteByCriteria(x=>x.Id == id);
        }

        public IList<ToDoList> ListToDoList()
        {
            var listToDoList = _toDoListRepository.FindAll();
            var mapToDoList = _mapper.Map<IList<Data.Entities.ToDoList>, IList<Domain.Models.ToDoList>>(listToDoList);
            return mapToDoList;
        }

        public ToDoList ReadToDoList(int id)
        {
            var ToDoList = _toDoListRepository.FindById(id);
            var mapToDoListResp = _mapper.Map<Data.Entities.ToDoList, Domain.Models.ToDoList>(ToDoList);
            return mapToDoListResp;
        }

        public ToDoList UpdateToDoList(ToDoList toDoList)
        {
            if (toDoList != null && toDoList.Id > 0)
            {
                var entityToDoItem = _toDoListRepository.FindById(toDoList.Id);
                if (entityToDoItem != null)
                {
                    entityToDoItem = MapToToDoItemEntityFromToDoItemModelForUpdate(toDoList, entityToDoItem);
                    toDoList = _mapper.Map<Domain.Models.ToDoList>(_toDoListRepository.Update(entityToDoItem));
                }
            }
            return toDoList;
        }

        private Data.Entities.ToDoList MapToToDoItemEntityFromToDoItemModelForUpdate(Domain.Models.ToDoList sourceToDoListModel, Data.Entities.ToDoList targetToDoListEntity)
        {
            targetToDoListEntity = _mapper.Map<Domain.Models.ToDoList, Data.Entities.ToDoList>(sourceToDoListModel, targetToDoListEntity,

                            opt =>
                                opt.BeforeMap((src, dest)
                                =>
                                {
                                    src.CreatedBy = dest.CreatedBy;
                                    src.CreatedOn = dest.CreatedOn;

                                })
                            );

            return targetToDoListEntity;
        }
    }
}
