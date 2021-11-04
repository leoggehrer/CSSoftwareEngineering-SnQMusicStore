//@GeneratedCode
namespace SnQMusicStore.AspMvc.Models.Persistence.MusicStore
{
    using System;
    public partial class Artist : SnQMusicStore.Contracts.Persistence.MusicStore.IArtist
    {
        static Artist()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Artist()
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
        public void CopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist other)
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
        partial void BeforeCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist other, ref bool handled);
        partial void AfterCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist other);
        public static Persistence.MusicStore.Artist Create()
        {
            BeforeCreate();
            var result = new Persistence.MusicStore.Artist();
            AfterCreate(result);
            return result;
        }
        public static Persistence.MusicStore.Artist Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.MusicStore.Artist();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.MusicStore.Artist Create(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist other)
        {
            BeforeCreate(other);
            var result = new Persistence.MusicStore.Artist();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.MusicStore.Artist instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.MusicStore.Artist instance, object other);
        static partial void BeforeCreate(SnQMusicStore.Contracts.Persistence.MusicStore.IArtist other);
        static partial void AfterCreate(Persistence.MusicStore.Artist instance, SnQMusicStore.Contracts.Persistence.MusicStore.IArtist other);
    }
}
