using csharp_in_a_nutshell._04_Advanced;


var video = new Video() { Title = "Beach Lasagna" };
var videoEncoder = new VideoEncoder(); //publisher

var mailService = new MailService(); //subsciber


videoEncoder.VideoEncoded += mailService.OnVideoEncoded;// we call the event


videoEncoder.Encode(video);



