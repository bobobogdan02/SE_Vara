using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.ViewModels
{
    public class ClassStreamViewModel
    {
        public Stream stream { get; set; }

        public Class Class { get; set; }

        public IList<Stream> streams { get; set; }
    }
}
