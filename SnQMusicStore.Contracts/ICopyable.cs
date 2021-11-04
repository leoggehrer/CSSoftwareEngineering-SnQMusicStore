//@CodeCopy

namespace SnQMusicStore.Contracts
{
	public partial interface ICopyable<T>
	{
		void CopyProperties(T other);
	}
}
