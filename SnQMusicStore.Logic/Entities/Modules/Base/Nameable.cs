//@GeneratedCode
namespace SnQMusicStore.Logic.Entities.Modules.Base
{
    using System;
    partial class Nameable : SnQMusicStore.Contracts.Modules.Base.INameable
    {
        static Nameable()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Nameable()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Name
        {
            get;
            set;
        }
        public void CopyProperties(SnQMusicStore.Contracts.Modules.Base.INameable other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Name = other.Name;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQMusicStore.Contracts.Modules.Base.INameable other, ref bool handled);
        partial void AfterCopyProperties(SnQMusicStore.Contracts.Modules.Base.INameable other);
        public override bool Equals(object obj)
        {
            if (obj is not SnQMusicStore.Contracts.Modules.Base.INameable instance)
            {
                return false;
            }
            return base.Equals(instance) && Equals(instance);
        }
        protected bool Equals(SnQMusicStore.Contracts.Modules.Base.INameable other)
        {
            if (other == null)
            {
                return false;
            }
            return IsEqualsWith(Name, other.Name);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public static Modules.Base.Nameable Create()
        {
            BeforeCreate();
            var result = new Modules.Base.Nameable();
            AfterCreate(result);
            return result;
        }
        public static Modules.Base.Nameable Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Base.Nameable();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Base.Nameable Create(SnQMusicStore.Contracts.Modules.Base.INameable other)
        {
            BeforeCreate(other);
            var result = new Modules.Base.Nameable();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Base.Nameable instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Base.Nameable instance, object other);
        static partial void BeforeCreate(SnQMusicStore.Contracts.Modules.Base.INameable other);
        static partial void AfterCreate(Modules.Base.Nameable instance, SnQMusicStore.Contracts.Modules.Base.INameable other);
    }
}
