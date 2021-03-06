//@CodeCopy
//MdStart
using System;

namespace SnQMusicStore.Logic.Entities
{
    internal partial class ModuleObject : EntityObject
    {
        public void CopyProperties(object other)
        {
            bool handled = false;

            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                this.CopyFrom(other);
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(Object other, ref bool handled);
        partial void AfterCopyProperties(Object other);
    }
}
//MdEnd
