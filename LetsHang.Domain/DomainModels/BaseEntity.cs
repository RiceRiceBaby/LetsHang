using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsHang.Domain.DomainModels
{
    public class BaseEntity
    {
        private IList<String> _validaetionErrors = new List<String>();

        [NotMapped]
        public IList<String> ValidationErrors
        {
            get { return _validaetionErrors; }
            set { _validaetionErrors = value; }
        }
    }
}
