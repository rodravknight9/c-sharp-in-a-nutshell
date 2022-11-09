using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_in_a_nutshell._04_Advanced
{
    internal class Events
    {
        //-- questions
        // when do the compilers knows who needs to call.

    }

    /// <summary>
    /// Class used for the Event example
    /// </summary>
    public class Broadcaster
    {
        public event PriceChangedHandler PriceChanged;
    }

    /// <summary>
    /// Stock events, simulates the changes of prices
    /// This is used for 
    /// </summary>
    public class StockEvent
    {
        string _symbol;
        decimal _price;

        public StockEvent(string symbol)
        {
            _symbol = symbol;
        }

        public event PriceChangedHandler PriceChanged;

        /// <summary>
        /// it fires the PriceChanged event every time the Price of the Stock changes.
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price == value) return;
                decimal oldPrice = _price;
                _price = value;
                if (PriceChanged != null) // if the invocation event is not empty, fires the event.
                {
                    PriceChanged(oldPrice, _price);
                }
            }
        }

    }


    //================================================================================
    //-- The following example is given by Programming with Mosh
    //-- https://youtu.be/jQgwEsJISy0

    /// <summary>
    /// This class is responsible to encode a video
    /// </summary>
    public class VideoEncoder
    {
        /// <summary>
        /// Delegates that is used as a contract
        /// </summary>
        /// <param name="source">The source the event has been called</param>
        /// <param name="e"></param>
        public delegate void VideoEncodedEventHandler(object source, EventArgs e);

        /// <summary>
        /// Event based on the delegate <b>VideoEncodedEventHandler</b> that raise the events
        /// </summary>
        public event VideoEncodedEventHandler VideoEncoded;

        /// <summary>
        /// Encodes the video.
        /// </summary>
        /// <param name="video"></param>
        public void Encode(Video video)
        {
            Console.WriteLine($"Encoding the video: {video.Title}");
            Thread.Sleep(2000);

            OnVideoEncoded(); // call the events if there is any.
        }

        /// <summary>
        /// Method resposible to raise the events
        /// </summary>
        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
            { 
                VideoEncoded(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Video class that contains a simple Title
    /// </summary>
    public class Video
    {
        public string Title { get; set; } = null!;
    }


    /// <summary>
    /// class responsible to send emails
    /// </summary>
    public class MailService
    {
        /// <summary>
        /// Subscriber method that accomplish the contract delegate with
        /// <b>VideoEncodedEventHandler</b>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("Mail Service: Sending an email...");
        }
        
    }

    public class TextService
    {
        /// <summary>
        /// Subscriber method that accomplish the contract delegate with
        /// <b>VideoEncodedEventHandler</b>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("Text Service: Sending an email...");
        }
    }


}
