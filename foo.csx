
/* NB. this doesn't work, because winforms requires a single thread. idk how to tell csi. */

#r "PresentationFramework"
#r "System.Windows.Forms"
#r "System.Web.Extensions"
#load "main.cs"

using System.Threading;

var newWindowThread = new Thread(new ThreadStart(() =>
{
    Program.Main(Args.ToArray());

}));
newWindowThread.SetApartmentState(ApartmentState.STA);
newWindowThread.IsBackground = true;
newWindowThread.Start();