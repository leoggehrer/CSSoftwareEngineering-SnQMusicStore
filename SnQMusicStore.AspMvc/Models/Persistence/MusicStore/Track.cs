//@GeneratedCode
namespace SnQMusicStore.AspMvc.Models.Persistence.MusicStore
{
    using System;
    public partial class Track : SnQMusicStore.Contracts.Persistence.MusicStore.ITrack
    {
        static Track()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Track()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 AlbumId
        {
            get;
            set;
        }
        public System.Int32 GenreId
        {
            get;
            set;
        }
        public System.String Title
        {
            get;
            set;
        }
        public System.String Composer
        {
            get;
            set;
        }
        public System.Int64 Milliseconds
        {
            get;
            set;
        }
        public System.Int64 Bytes
        {
            get;
            set;
        }
        public System.Double UnitPrice
        {
            get;
            set;
        }
        public void CopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack other)
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
                AlbumId = other.AlbumId;
                GenreId = other.GenreId;
                Title = other.Title;
                Composer = other.Composer;
                Milliseconds = other.Milliseconds;
                Bytes = other.Bytes;
                UnitPrice = other.UnitPrice;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack other, ref bool handled);
        partial void AfterCopyProperties(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack other);
        public static Persistence.MusicStore.Track Create()
        {
            BeforeCreate();
            var result = new Persistence.MusicStore.Track();
            AfterCreate(result);
            return result;
        }
        public static Persistence.MusicStore.Track Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.MusicStore.Track();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.MusicStore.Track Create(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack other)
        {
            BeforeCreate(other);
            var result = new Persistence.MusicStore.Track();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.MusicStore.Track instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.MusicStore.Track instance, object other);
        static partial void BeforeCreate(SnQMusicStore.Contracts.Persistence.MusicStore.ITrack other);
        static partial void AfterCreate(Persistence.MusicStore.Track instance, SnQMusicStore.Contracts.Persistence.MusicStore.ITrack other);
    }
}
