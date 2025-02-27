using DreemDay_Core.Context;
using DreemDay_Core.DTOs.WishListDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class WishListRepos : IWishListRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public WishListRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateWishList(WishList wishList)
        {
           
            _dbContext.Add(wishList);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging CreateWishList Has been Finised Successfully");
            return wishList.Id;
        }

        public async Task DeleteWishList(int id)
        {
          var wishlist = await _dbContext.WishLists.FindAsync(id);
          if (wishlist == null)
          {
            Log.Warning("Wishlist with ID {Id} was not found.", id);
            return;
          }
       
          Log.Information("Wishlist with ID {Id} exists.", id);
       
          wishlist.IsDeleted = true;
          _dbContext.Update(wishlist);
          await _dbContext.SaveChangesAsync();
       
          Log.Debug("MarkWishListAsDeleted has completed successfully for wishlist ID {Id}.", id);
        }
      

    

        public async Task<List<WishListCardDto>> GetAllWishList()
        {
            var WL = await _dbContext.WishLists
                .Where(x => x.IsDeleted == false)
                .Join(_dbContext.Users, wl => wl.UserId, u => u.Id, (wl, u) => new {WishList=wl,User=u})
                .Join(_dbContext.Services,wlUser => wlUser.WishList.ServiceId, 
                       s => s.Id,(wlUser, service) => new { WishListUser = wlUser, Service = service })

                .Select(wishlist => new WishListCardDto
                {
                    Id = wishlist.WishListUser.WishList.Id,
                    ServiceId = wishlist.Service.Id,
                    UserId = wishlist.WishListUser.User.Id,
                    ServiceName = wishlist.Service.Name,
                    ServiceImage= $"https://localhost:44324/Images/{wishlist.Service.Image}"
                }).ToListAsync();
            Log.Debug("Debugging GetAllWishList Has been Finised Successfully");
            return WL;
        }

        public async Task<WishListByIdDto> GetWishList(int id)
        {
            var wishlist = await _dbContext.WishLists
                .Where(wl => wl.Id == id) 
                .Join(_dbContext.Users, wl => wl.UserId, u => u.Id, (wl, u) => new { WishList = wl, User = u })
                .Join(_dbContext.Services,
                    wlUser => wlUser.WishList.ServiceId,
                    s => s.Id,
                    (wlUser, service) => new { WishListUser = wlUser, Service = service })
                .FirstOrDefaultAsync(); 

            if (wishlist == null) 
                return null;
            Log.Information("WishList Is Exists");
            var WL = new WishListByIdDto
            {
                Id = wishlist.WishListUser.WishList.Id,
                ServiceId = wishlist.WishListUser.WishList.ServiceId,
                UserId = wishlist.WishListUser.User.Id,
                CreationDate = wishlist.WishListUser.WishList.CreationDate.ToString(),
                ModifiedDate = wishlist.WishListUser.WishList.ModifiedDate.ToString(),
                IsDeleted = wishlist.WishListUser.WishList.IsDeleted ?? false,
                ServiceImage = wishlist.Service.Image

            };
            Log.Debug("Debugging GetWishList Has been Finised Successfully");
            return WL;
        }


        public async Task UpdateWishList(UpdateWishListDto updateWishListDto)
        {
            var wishlist = await _dbContext.WishLists.FindAsync(updateWishListDto.Id);
            if (wishlist == null)
                return;
            Log.Information("WishList Is Exists");
            wishlist.ServiceId = updateWishListDto.ServiceId;
            wishlist.CreationDate=updateWishListDto.CreationDate;
            wishlist.ModifiedDate=DateTime.Now;
            wishlist.IsDeleted = updateWishListDto.IsDeleted;
            _dbContext.Update(wishlist);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging UpdateWishList Has been Finised Successfully");


        }
    }
}
