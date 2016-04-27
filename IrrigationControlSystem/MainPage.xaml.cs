using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Web.Http;
using Windows.Web.Http.Filters;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IrrigationControlSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private HttpClient httpClient = new HttpClient();
        private CancellationTokenSource cts;

        private Timer peroidicTimer;

        private String sValue1, sValue2, sValue3;

        public object Helpers { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
            //Helpers.CreateHttpClient(ref httpClient);
            sValue1 = "No Data";
            sValue2 = "No Data";
            sValue3 = "No Data";
            cts = new CancellationTokenSource();
            peroidicTimer = new Timer(this.TimerCallBack, null, 0, 5000);

        }

        private void TimerCallBack(object state)
        {
            rpiRun();
        }
        private async void rpiRun() {
            // Get Moisture value1
            try
            {
                Uri resourceAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveMoistureA0/moisture?access_token=691b1d3564d910098115ba03ee18fa35");
                var filter = new HttpBaseProtocolFilter();
                filter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;

                using (var client = new HttpClient(filter)) {
                    HttpResponseMessage response = await client.GetAsync(resourceAddress).AsTask();
                    if (response != null && response.StatusCode == HttpStatusCode.Ok) {

                        JsonObject parser = JsonObject.Parse(await response.Content.ReadAsStringAsync());
                        double ivalue = parser["moisture"].GetNumber() / 650 * 100;
                        sValue1 = ivalue.ToString("F2") + "%";
                    }
                }
            }
            catch
            {
            }
            // Get Moisture value2
            try
            {
                Uri resourceAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveMoistureA0/moisture?access_token=691b1d3564d910098115ba03ee18fa35");
                var filter = new HttpBaseProtocolFilter();
                filter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;

                using (var client = new HttpClient(filter))
                {
                    HttpResponseMessage response = await client.GetAsync(resourceAddress).AsTask();
                    if (response != null && response.StatusCode == HttpStatusCode.Ok)
                    {

                        JsonObject parser = JsonObject.Parse(await response.Content.ReadAsStringAsync());
                        double ivalue = parser["moisture"].GetNumber() / 650 * 100;
                        sValue2 = ivalue.ToString("F2") + "%";
                    }
                }
            }
            catch
            {
            }

            // Get Moisture value3
            try
            {
                Uri resourceAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveMoistureA0/moisture?access_token=691b1d3564d910098115ba03ee18fa35");
                var filter = new HttpBaseProtocolFilter();
                filter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;

                using (var client = new HttpClient(filter))
                {
                    HttpResponseMessage response = await client.GetAsync(resourceAddress).AsTask();
                    if (response != null && response.StatusCode == HttpStatusCode.Ok)
                    {

                        JsonObject parser = JsonObject.Parse(await response.Content.ReadAsStringAsync());
                        double ivalue = parser["moisture"].GetNumber() / 650 * 100;
                        sValue3 = ivalue.ToString("F2") + "%";
                    }
                }
            }
            catch
            {
            }



            var UItask = this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 Value1.Text = sValue1;
                 Value2.Text = sValue2;
                 Value3.Text = sValue3;
             });

        }

        private async void ToggleButton_Checked1(object sender, RoutedEventArgs e)
        {
            Toggle1.Content = "Close";
            Uri resoureAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveRelayD0/onoff/1?access_token=32f0d644e3e21cca8eef8df19dac244d");
            try {
                HttpResponseMessage response = await httpClient.PostAsync(resoureAddress,
                    new HttpStringContent("")).AsTask(cts.Token);
            }

            catch (Exception ex)
            {
               
            }
            finally
            {
            }
        }

        private async void ToggleButton_Unchecked1(object sender, RoutedEventArgs e)
        {
            Toggle1.Content = "Open";
            Uri resoureAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveRelayD0/onoff/0?access_token=32f0d644e3e21cca8eef8df19dac244d");
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(resoureAddress,
                    new HttpStringContent("")).AsTask(cts.Token);
            }

            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private async void ToggleButton_Checked2(object sender, RoutedEventArgs e)
        {
            Toggle2.Content = "Close";
            Uri resoureAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveRelayD0/onoff/1?access_token=691b1d3564d910098115ba03ee18fa35");
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(resoureAddress,
                    new HttpStringContent("")).AsTask(cts.Token);
            }

            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private async void ToggleButton_Unchecked2(object sender, RoutedEventArgs e)
        {
            Toggle2.Content = "Open";
            Uri resoureAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveRelayD0/onoff/0?access_token=691b1d3564d910098115ba03ee18fa35");
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(resoureAddress,
                    new HttpStringContent("")).AsTask(cts.Token);
            }

            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private async void ToggleButton_Checked3(object sender, RoutedEventArgs e)
        {
            Toggle3.Content = "Close";
            Uri resoureAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveRelayD0/onoff/1?access_token=691b1d3564d910098115ba03ee18fa35");
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(resoureAddress,
                    new HttpStringContent("")).AsTask(cts.Token);
            }

            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private async void ToggleButton_Unchecked3(object sender, RoutedEventArgs e)
        {
            Toggle3.Content = "Open";
            Uri resoureAddress = new Uri("https://cn.iot.seeed.cc/v1/node/GroveRelayD0/onoff/0?access_token=691b1d3564d910098115ba03ee18fa35");
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(resoureAddress,
                    new HttpStringContent("")).AsTask(cts.Token);
            }

            catch (Exception ex)
            {

            }
            finally
            {
            }
        }


    }
}
