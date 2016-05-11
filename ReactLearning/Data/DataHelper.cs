using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactLearning
{
    public class DataHelper
    {
        private static string path = "testData.db";
        public static bool Add<T>(T obj) where T : new()
        {
            using (LiteDB.LiteDatabase db = new LiteDB.LiteDatabase(path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
                var result = collection.Insert(obj);
                if (result.AsInt32>0)
                {
                    return true;
                }
                else return false;
            }
        }

        public static bool Update<T>(T obj) where T : new()
        {
            using (LiteDB.LiteDatabase db = new LiteDB.LiteDatabase(path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
                var result = collection.Update(obj);
                return result;
            }
        }


        public static bool Delete<T>(int id) where T : new()
        {
            using (LiteDB.LiteDatabase db = new LiteDB.LiteDatabase(path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
                var result = collection.Delete(new LiteDB.BsonValue(id));
                return result;
            }
        }

        public static List<T> QueryAll<T>() where T : new()
        {
            using (LiteDB.LiteDatabase db = new LiteDB.LiteDatabase(path))
            {
                var collection = db.GetCollection<T>(GetCollectionName(typeof(T)));
                var result = collection.FindAll().ToList();
                return result;
            }
        }

        private static string GetCollectionName(Type t)
        {
            return t.FullName.Replace(".", "");
        }


    }
}