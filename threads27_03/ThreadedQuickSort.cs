using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threads27_03
{
	public class ThreadedQuickSort<T> where T : IComparable<T>
	{
		public async Task QuickSort(T[] arr)
		{
			await QuickSort(arr, 0, arr.Length - 1);
		}

		private async Task QuickSort(T[] arr, int left, int right)
		{

			if (right <= left) return;
			int lt = left;
			int gt = right;
			var pivot = arr[left];
			int i = left + 1;
			while (i <= gt)
			{
				int cmp = arr[i].CompareTo(pivot);
				if (cmp < 0)
					Swap(arr, lt++, i++);
				else if (cmp > 0)
					Swap(arr, i, gt--);
				else
					i++;
			}

			var t1 = Task.Run(() => QuickSort(arr, left, lt - 1));
			var t2 = Task.Run(() => QuickSort(arr, gt + 1, right));

			await Task.WhenAll(t1, t2).ConfigureAwait(false);

		}
		private void Swap(T[] a, int i, int j)
		{
			var swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}
    }
}
