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

        

        public ToDoItem CreateToDoItem(ToDoItem toDoItem)
        {
            if (toDoItem == null)
                return null;

            var mapToDoItem = _mapper.Map<Data.Entities.ToDoItem>(toDoItem);
            return _mapper.Map<Models.ToDoItem>(_toDoItemRepository.Create(mapToDoItem));

        }

        public void DeleteToDoItem(int id)
        {
            _toDoItemRepository.DeleteByCriteria(x => x.Id == id);
        }

        public IList<ToDoItem> ListToDoItem()
        {
            var listToDoItems = _toDoItemRepository.FindAll();
            var mapToDoItem = _mapper.Map<IList<Data.Entities.ToDoItem>, IList<Domain.Models.ToDoItem>>(listToDoItems);
            return mapToDoItem;
        }
        

        public ToDoItem ReadToDoItem(int id)
        {
            var toDoItem = _toDoItemRepository.FindById(id);
            var mapToDoItemResp = _mapper.Map<Data.Entities.ToDoItem, Domain.Models.ToDoItem> (toDoItem);
            return mapToDoItemResp;
        }

        public ToDoItem UpdateToDoItem(ToDoItem toDoItem)
        {
            if (toDoItem != null && toDoItem.Id > 0)
            {
                var entityToDoItem = _toDoItemRepository.FindById(toDoItem.Id);
                if (entityToDoItem != null)
                {
                    entityToDoItem = MapToToDoItemEntityFromToDoItemModelForUpdate(toDoItem, entityToDoItem);
                    toDoItem = _mapper.Map<Domain.Models.ToDoItem>(_toDoItemRepository.Update(entityToDoItem));
                }
            }
            return toDoItem;
        }

        private Data.Entities.ToDoItem MapToToDoItemEntityFromToDoItemModelForUpdate(Domain.Models.ToDoItem sourceToDoItemModel, Data.Entities.ToDoItem targetToDoItemEntity)
        {
            targetToDoItemEntity = _mapper.Map<Domain.Models.ToDoItem, Data.Entities.ToDoItem>(sourceToDoItemModel, targetToDoItemEntity,

                            opt =>
                                opt.BeforeMap((src, dest)
                                =>
                                {
                                    src.CreatedBy = dest.CreatedBy;
                                    src.CreatedOn = dest.CreatedOn;

                                    if (src.ToDoList == null && dest.ToDoList != null)
                                    {
                                        src.ToDoList = _mapper.Map<ToDoList>(dest.ToDoList);
                                    }

                                })
                            );

            return targetToDoItemEntity;
        }
    }
}
