using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkaidoNyilvantarto.Desktop.Services
{
    public class ServiceResult
    {
        public bool Succeeded { get; set; }

        public List<KeyValuePair<string, string>> Errors { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}
