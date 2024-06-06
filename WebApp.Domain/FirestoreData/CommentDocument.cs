using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.FirestoreData
{
    [FirestoreData]
    public class CommentDocument
    {
        [FirestoreDocumentId]
        public string commentId { get; set; }
        [FirestoreProperty]
        public string commRating { get; set; }

        [FirestoreProperty]
        public string nickname { get; set; }

        [FirestoreProperty]
        public string content { get; set; }

        [FirestoreProperty]
        public DateTime datePostedComment { get; set; }
    }
}
