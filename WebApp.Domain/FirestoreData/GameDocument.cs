using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.FirestoreData
{
    [FirestoreData]
    public class GameDocument
    {
        [FirestoreDocumentId]
        public string gameId { get; set; }
        [FirestoreProperty]
        public required string title { get; set; }
        [FirestoreProperty]
        public required string description { get; set; }
        [FirestoreProperty]
        public required string genre { get; set; }
        [FirestoreProperty]
        public List<string> reviewId { get; set; }

    }
}
