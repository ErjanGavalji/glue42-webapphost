using DOT.AGM.Services;
using System;
using System.Collections.Generic;

namespace DotNetCaller
{
    [ServiceContract(MethodNamespace = "T42.Wnd.")]
    public interface IContextSetter : IDisposable
    {
        [ServiceOperation(AsyncIfPossible = true, ExceptionSafe = false)]
        void Execute(string command, string windowId, IDictionary<string, string> context);
    }
}
