//@GeneratedCode
namespace SnQMusicStore.Logic.Entities.Persistence.MusicStore
{
    using System;
    partial class Genre : SnQMusicStore.Contracts.Persistence.MusicStore.IGenre
    {
        static Genre()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Genre()
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
        public void CopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                Name = other.Name;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre other, ref bool handled);
        partial void AfterCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre other);
        public override bool Equals(object obj)
        {
            if (obj is not SnQMusicStore.Contracts.Persistence.MusicStore.IGenre instance)
            {
                return false;
            }
            return base.Equals(instance) && Equals(instance);
        }
        protected bool Equals(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre other)
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
        public static Persistence.MusicStore.Genre Create()
        {
            BeforeCreate();
            var result = new Persistence.MusicStore.Genre();
            AfterCreate(result);
            return result;
        }
        public static Persistence.MusicStore.Genre Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.MusicStore.Genre();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.MusicStore.Genre Create(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre other)
        {
            BeforeCreate(other);
            var result = new Persistence.MusicStore.Genre();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.MusicStore.Genre instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.MusicStore.Genre instance, object other);
        static partial void BeforeCreate(SnQMusicStore.Contracts.Persistence.MusicStore.IGenre other);
        static partial void AfterCreate(Persistence.MusicStore.Genre instance, SnQMusicStore.Contracts.Persistence.MusicStore.IGenre other);
    }
}
