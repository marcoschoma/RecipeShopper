using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public void InitConfigurations()
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
