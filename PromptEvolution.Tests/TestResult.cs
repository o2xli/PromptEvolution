using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptEvolution.Tests
{
    internal class TestResult<T>
    {
        public string Request { get; set; } = null!;
        public T? Result { get; set; }
    }
}
