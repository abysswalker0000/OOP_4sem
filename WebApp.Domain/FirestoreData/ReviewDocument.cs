using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.FirestoreData
{
    [FirestoreData]
    public class ReviewDocument
    {
        [FirestoreDocumentId]
        public string reviewId { get; set; }

        [FirestoreProperty]
        public string content { get; set; }

        [FirestoreProperty]
        public double rating { get; set; }

        [FirestoreProperty]
        public string gameId { get; set; } 
    }
}
