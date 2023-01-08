using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.ViewModels.Utilities
{
	public partial class VMBase : ObservableObject
	{
		[ObservableProperty]
		String title;

		[ObservableProperty]
		bool isBusy;


	}
}
