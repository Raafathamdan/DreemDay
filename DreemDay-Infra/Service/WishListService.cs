using DreemDay_Core.DTOs.WishListDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepos _repos;
        private readonly IUserRepos _userRepos;
        public WishListService(IWishListRepos repos, IUserRepos userRepos)
        {
            _repos = repos;
            _userRepos = userRepos;
        }

        public async Task CreateWishList(CreateWishListDto createWishListDto)
        {
            var user = await _userRepos.GetUser(createWishListDto.Id);
            if (user != null)
            {
                var wishList = new WishList();

                wishList.ServiceId = createWishListDto.SerciceId;
                wishList.UserId = user.Id;
                wishList.CreationDate = DateTime.Now;
                wishList.IsDeleted = false;

                await _repos.CreateWishList(wishList);
                var id = await _repos.CreateWishList(wishList);
                if (id == 0)
                    throw new Exception("Failed To Create Wish List");

            }
            throw new Exception("User Dose Not Exisit");

        }

        public async Task DeleteWishList(int id)
        {
            await _repos.DeleteWishList(id);
        }

        public async Task<List<WishListCardDto>> GetAllWishList()
        {
            return await _repos.GetAllWishList();
        }

        public async Task<WishListByIdDto> GetWishList(int id)
        {
            return await _repos.GetWishList(id);
        }

        public async Task UpdateWishList(UpdateWishListDto updateWishListDto)
        {
            await _repos.UpdateWishList(updateWishListDto);
        }
    }
}
