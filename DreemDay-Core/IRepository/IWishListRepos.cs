using DreemDay_Core.DTOs.WishListDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface IWishListRepos
    {
        Task<List<WishListCardDto>> GetAllWishList();
        Task<WishListByIdDto> GetWishList(int id);
        Task<int> CreateWishList(WishList wishList);
        Task UpdateWishList(UpdateWishListDto updateWishListDto);
        Task DeleteWishList(int id);
    }
}
