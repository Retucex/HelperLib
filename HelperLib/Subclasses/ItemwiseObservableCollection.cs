using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace HelperLib.Subclasses
{
	/// <summary>
	/// ObservableCollection that triggers OnCollectionChanged when item's OnPropertyChanged triggers.
	/// </summary>
	/// <typeparam name="T">Elements must implement INotifyPropertyChanged</typeparam>
	public class ItemwiseObservableCollection<T> : ObservableCollection<T>
			where T : INotifyPropertyChanged
	{
		public ItemwiseObservableCollection()
		{
			CollectionChanged += TrulyObservableCollection_CollectionChanged;
		}

		void TrulyObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null)
			{
				foreach (Object item in e.NewItems)
				{
					(item as INotifyPropertyChanged).PropertyChanged += item_PropertyChanged;
				}
			}
			if (e.OldItems != null)
			{
				foreach (Object item in e.OldItems)
				{
					(item as INotifyPropertyChanged).PropertyChanged -= item_PropertyChanged;
				}
			}
		}

		void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
			OnCollectionChanged(a);
		}
	}
}
