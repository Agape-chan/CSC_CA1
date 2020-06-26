using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace task5
{
    public partial class _Default : Page
    {

        private const string bucketName = "csctask5agapechan";
        private const string objectKey = "AKIATZH7I3Q7YKIJQSHB";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            System.IO.Stream stream = FileUpload1.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(stream);
            Byte[] bytes = br.ReadBytes((Int32)stream.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/jpeg;base64," + base64String;
            Image1.Visible = true;

            var awsKey = "AKIATZH7I3Q7YKIJQSHB";
            var awsSecretKey = "Y6P64C2WiJw83tF9CN2TJ+jfvUk7vRoUjR2qeviM";
            var bucketRegion = Amazon.RegionEndpoint.USEast1;   // Your bucket region
            var s3 = new AmazonS3Client(awsKey, awsSecretKey, bucketRegion);
            var putRequest = new PutObjectRequest();
            putRequest.BucketName = "csctask5agapechan";        // Your bucket name
            putRequest.ContentType = "image/jpeg";
            putRequest.InputStream = FileUpload1.PostedFile.InputStream;
            // key will be the name of the image in your bucket
            putRequest.Key = FileUpload1.FileName;
            PutObjectResponse putResponse = s3.PutObject(putRequest);

            s3Client = new AmazonS3Client(bucketRegion);
            string urlString = "";

            urlString = GeneratePreSignedURL();

            objectLink.Text = urlString;
            objectLink.Visible = true;
        }

        static string GeneratePreSignedURL()
        {
            string urlString = "";
            try
            {
                GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    Expires = DateTime.Now.AddMinutes(5)
                };
                urlString = s3Client.GetPreSignedURL(request1);
                Console.WriteLine(urlString);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            return urlString;
        }
    }
    
}