using Microsoft.EntityFrameworkCore;
using QLBH.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Addess_Receive> Addess_Receive { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Detail_Cart> Detail_Cart { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<ImageProduct> ImageProduct { get; set; }
        public DbSet<ConfirmEmail> ConfirmEmail { get; set; }
        public DbSet<Invoice_Details> Invoice_Details { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCatogory> ProductCatogory { get; set; }
        public DbSet<RefeshToken> RefeshToken { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Status_Bill> Status_Bill { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<MailSetting> MailSetting { get; set; }
        public DbSet<Decentralization> Decentralization { get; set; }
        public DbSet<Comment_Product> Comment_Product { get; set; }
        public DbSet<Image_Comment> Image_Comment { get; set; }

        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
