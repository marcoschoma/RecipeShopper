using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Domain.Commands
{
    public class PaginatedList<T> where T : ICommandResult
    {
        private object items;
        private int count;
        private int pageNumber;
        private int pageSize;

        public PaginatedList(object items, int count, int pageNumber, int pageSize)
        {
            this.items = items;
            this.count = count;
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
    }
}
