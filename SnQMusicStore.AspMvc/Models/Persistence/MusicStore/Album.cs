//@GeneratedCode
namespace SnQMusicStore.AspMvc.Models.Persistence.MusicStore
{
    using System;
    public partial class Album : SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum
    {
        static Album()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Album()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 ArtistId
        {
            get;
            set;
        }
        public System.String Title
        {
            get;
            set;
        }
        public void CopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum other)
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
                ArtistId = other.ArtistId;
                Title = other.Title;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum other, ref bool handled);
        partial void AfterCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum other);
        public static Persistence.MusicStore.Album Create()
        {
            BeforeCreate();
            var result = new Persistence.MusicStore.Album();
            AfterCreate(result);
            return result;
        }
        public static Persistence.MusicStore.Album Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.MusicStore.Album();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.MusicStore.Album Create(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum other)
        {
            BeforeCreate(other);
            var result = new Persistence.MusicStore.Album();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.MusicStore.Album instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.MusicStore.Album instance, object other);
        static partial void BeforeCreate(SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum other);
        static partial void AfterCreate(Persistence.MusicStore.Album instance, SnQMusicStore.Contracts.Persistence.MusicStore.IAlbum other);
    }
}
