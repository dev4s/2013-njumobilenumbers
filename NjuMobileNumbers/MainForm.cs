using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NjuMobileNumbers
{
	public partial class MainForm : Form
	{
		private Queue<string> _queue; 
		private ConcurrentQueue<string> _webBrowserDocuments;
		private TaskScheduler _uiScheduler;
		private BindingList<string> _objects;
		private bool _backgroundTaskRunning;

		private Progress<List<string>> _progress;

		private List<string> _values; 

		private const string Previous = "msisdn-pool-prev";
		private const string Next = "msisdn-pool-next";

		public MainForm()
		{
			WebBrowserEmulation.Change(BrowserEmulation.IE10);

			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_values.AddRange(new[] {"test1", "test2"});
			dataGridView1.RowCount = _values.Count;

			//var test = new VirtualizingStackPanel()

			//_webBrowserDocuments = new ConcurrentQueue<string>();
			//_queue = new Queue<string>(50);
			//_uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

			////_progress = new Progress<List<string>>();
			////_progress.ProgressChanged += (o, numbers) =>
			////	{
			////		listBoxNumbers.SuspendLayout();
			////		foreach (var n in numbers)
			////		{
			////			_objects.Add(n);
			////		}
			////		listBoxNumbers.ResumeLayout();
			////	};

			//_objects = new BindingList<string>();
			//listBoxNumbers.DataSource = _objects;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			WebBrowserEmulation.Delete();
		}

		private async void buttonWebScrap_Click(object sender, EventArgs e)
		{
			await WebBrowserClickLinkAsync("/ptk/sun/core/cookie/CookiesHandler.accept");

			if (_backgroundTaskRunning || !(await WebBrowserClickLinkAsync("msisdn-change"))) return;

			await Task.Delay(5000);
			var cts = new CancellationTokenSource();

			await WebBrowserDocumentDownloadAsync(cts);
			await DocumentParseAsync(_progress, cts);

			_backgroundTaskRunning = true;
		}

		private async Task DocumentParseAsync(IProgress<List<string>> progress, CancellationTokenSource cts)
		{
			await Task.Factory.StartNew(() =>
				{
					var tempNumbers = new List<string>(200);
					var htmlDoc = new HtmlAgilityPack.HtmlDocument();

					while (true)
					{
						if (_queue.Count > 0)
						{
							var tempDocument = _queue.Dequeue();

							if (!string.IsNullOrEmpty(tempDocument))
							{
								htmlDoc.LoadHtml(tempDocument);

								tempNumbers.AddRange(htmlDoc.DocumentNode.SelectNodes("//a[starts-with(@id, 'msisdn')]")
								                            .Where(number => number.Id != Previous && number.Id != Next)
								                            .Select(x => x.InnerText.RemoveEnters().RemoveSpaces().ReplaceSpecificChars()));
								tempNumbers.Add("----------------------------------");

								if (tempNumbers.Count > 100)
								{
									progress.Report(tempNumbers);
									tempNumbers = new List<string>(200);
								}
							}
						}
						
						if (cts.IsCancellationRequested)
						{
							break;
						}
					}
				}, cts.Token);
		}

		private async Task WebBrowserDocumentDownloadAsync(CancellationTokenSource cts)
		{
			await Task.Factory.StartNew(async () =>
				{
					while (true)
					{
						await Task.Delay(1000);

						//_webBrowserDocuments.Enqueue(webBrowser.DocumentText);
						_queue.Enqueue(webBrowser.DocumentText);

						if (await WebBrowserClickLinkAsync(Next)) continue;
						cts.Cancel();
						break;
					}
				}, new CancellationToken(), TaskCreationOptions.None, _uiScheduler);
		}

		private async Task<bool> WebBrowserClickLinkAsync(string linkId)
		{
			return await Task.Factory.StartNew(() =>
				{
					if (webBrowser.Document != null)
					{
						var elementById = webBrowser.Document.GetElementById(linkId);

						if (elementById != null)
						{
							elementById.InvokeMember("click");
						}
						else
						{
							return false;
						}

						if (webBrowser.Document.Window != null)
						{
							webBrowser.Document.Window.ScrollTo(0, 480);
						}
					}
					else
					{
						return false;
					}

					return true;
				}, new CancellationToken(), TaskCreationOptions.None, _uiScheduler);
		}

		private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			e.Value = _values[e.RowIndex];
		}
	}
}
