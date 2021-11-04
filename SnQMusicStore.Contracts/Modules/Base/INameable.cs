﻿//@Ignore
using CommonBase.Attributes;

namespace SnQMusicStore.Contracts.Modules.Base
{
    public partial interface INameable
    {
        [ContractPropertyInfo(Required = true, MaxLength = 256, IsUnique = true)]
        string Name { get; set; }
    }
}
