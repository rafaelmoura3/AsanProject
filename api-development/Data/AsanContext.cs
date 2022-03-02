using AsanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsanAPI.Data
{
    public class AsanContext : DbContext
    {
        public AsanContext(DbContextOptions<AsanContext> options) : base(options)
        {
        }

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<ToolPerPart> ToolPerParts { get; set; }
        public DbSet<SpaceShip> SpaceShips { get; set; }
        public DbSet<SpaceShipType> SpaceShipTypes { get; set; }
        public DbSet<SpaceShipProblem> SpaceShipProblems { get; set; }
        public DbSet<PartsPerShipType> PartsPerShipTypes { get; set; }
        public DbSet<PartsPerShip> PartsPerShips { get; set; }



        //VALIDAR O RESTRICT!!!!!!
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //n-n
            builder.Entity<ToolPerPart>()
               .HasOne(toolspearparts => toolspearparts.Part)
               .WithMany(tools => tools.ToolPerParts)
               .HasForeignKey(toolspearparts => toolspearparts.PartId).IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
            //n-n
            builder.Entity<ToolPerPart>()
                .HasOne(toolspearparts => toolspearparts.Tool)
                .WithMany(parts => parts.ToolPerParts)
                .HasForeignKey(toolspearparts => toolspearparts.ToolId).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            //1-n
            builder.Entity<PartsPerShipType>()
               .HasOne(partsPerShipType => partsPerShipType.SpaceShipType)
               .WithMany(spaceShipType => spaceShipType.PartsPerShipType)
               .HasForeignKey(partsPerShipType => partsPerShipType.SpaceShipTypeId).IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
            //1-n
            builder.Entity<PartsPerShipType>()
               .HasOne(partsPerShipType => partsPerShipType.Part)
               .WithMany(part => part.PartsPerShipType)
               .HasForeignKey(partsPerShipType => partsPerShipType.PartId).IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            //1 - n 
            builder.Entity<SpaceShip>()
                .HasOne(spaceShip => spaceShip.SpaceShipType)
                .WithMany(spaceShipType => spaceShipType.SpaceShip)
                .HasForeignKey(spaceShip => spaceShip.SpaceShipTypeId).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            //1 - n 
            builder.Entity<SpaceShipProblem>()
                .HasOne(spaceShipProblem => spaceShipProblem.Problem)
                .WithMany(problem => problem.SpaceShipProblem)
                .HasForeignKey(spaceShipProblem => spaceShipProblem.ProblemId).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SpaceShipProblem>()
                .HasOne(spaceShipProblem => spaceShipProblem.Part)
                .WithMany(part => part.SpaceShipProblem)
                .HasForeignKey(spaceShipProblem => spaceShipProblem.PartId).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SpaceShipProblem>()
                .HasOne(spaceShipProblem => spaceShipProblem.SpaceShip)
                .WithMany(spaceShip => spaceShip.SpaceShipProblem)
                .HasForeignKey(spaceShipProblem => spaceShipProblem.SpaceShipId).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Maintenance>()
                .HasOne(maintenance => maintenance.ToolPerPart)
                .WithMany(toolPerPart => toolPerPart.Maintenance)
                .HasForeignKey(maintenance => maintenance.ToolPerPartId).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Maintenance>()
                .HasOne(maintenance => maintenance.SpaceShipProblem)
                .WithMany(spaceShipProblem => spaceShipProblem.Maintenance)
                .HasForeignKey(maintenance => maintenance.SpaceShipProblemId).IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);    
            
            builder.Entity<PartsPerShip>()
               .HasOne(partsPerShip => partsPerShip.SpaceShip)
               .WithMany(spaceShip => spaceShip.PartsPerShip)
               .HasForeignKey(partsPerShip => partsPerShip.SpaceShipId).IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<PartsPerShip>()
               .HasOne(partsPerShip => partsPerShip.Part)
               .WithMany(part => part.PartsPerShip)
               .HasForeignKey(partsPerShip => partsPerShip.PartId).IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PartsPerShip>()
               .HasOne(partsPerShip => partsPerShip.PartsPerShipType)
               .WithMany(partsPerShipType => partsPerShipType.PartsPerShip)
               .HasForeignKey(partsPerShip => partsPerShip.PartsPerShipTypeId).IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            
            //Space ship problem x problem


            //TEM QUE TESTAR
            builder.Entity<SpaceShip>()
                .Property(p => p.Health)
                .HasDefaultValue(1);

        }

    }
}
