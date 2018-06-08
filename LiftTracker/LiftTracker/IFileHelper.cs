using System;
using System.Collections.Generic;
using System.Text;

namespace LiftTracker
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
