using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.News.Queries.GetNewsById;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.PromotedItem.Queries.GetPromotedItemById
{
    public class GetPromotedItemByIdQueryHandle : IRequestHandler<GetPromotedItemByIdQuery, GetPromotedItemByIdQuery>
    {
        private readonly IMapper _mapper;
        private readonly IPromotedItemRespository _promotedItemRespository;

        public GetPromotedItemByIdQueryHandle(IPromotedItemRespository promotedItemRespository, IMapper mapper)
        {
            _promotedItemRespository = promotedItemRespository;
            _mapper = mapper;
        }
        public async Task<GetPromotedItemByIdQuery> Handle(GetPromotedItemByIdQuery request, CancellationToken cancellationToken)
        {
            var promotedItem = await _promotedItemRespository.GetPromotedItemById(request.IdPromotedItem);
            var promotedItemDto = _mapper.Map<GetPromotedItemByIdQuery>(promotedItem);
            return promotedItemDto;
        }
    }
}
