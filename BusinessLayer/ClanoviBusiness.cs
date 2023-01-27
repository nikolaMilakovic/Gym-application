using DataLayer;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ClanoviBusiness  
    {
        private readonly ClanoviRepository clanoviRepository;
        public ClanoviBusiness()
        {
            this.clanoviRepository = new ClanoviRepository();
        }

        public List<Clanovi> GetAllMember()
        {
            return this.clanoviRepository.GetAllMember();
        }

        public bool InsertMember(Clanovi c)
        {
            if (this.clanoviRepository.InsertMember(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateMember(Clanovi c)
        {
            if (this.clanoviRepository.UpdateMember(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteMember(Clanovi c)
        {
            if (this.clanoviRepository.DeleteMember(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
