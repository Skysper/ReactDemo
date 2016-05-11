using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearning.Tests.Data
{
    [TestClass]
    public class DataHelperTest
    {
        [TestMethod]
        public void AddTest()
        {
            Models.Comment c = new Models.Comment() { Title="test" };
            bool result = DataHelper.Add<Models.Comment>(c);
            Assert.IsTrue(result, "数据库添加失败");
        }

        [TestMethod]
        public void UpdateTest()
        {
            var result = DataHelper.QueryAll<Models.Comment>();
            Assert.IsTrue(result != null && result.Count >= 0);
            Models.Comment c = null;
            if (result.Count > 0)
            {
                c = result[0];
                c.Title = "";
                c.Author = "Update";
                bool isUpdate = DataHelper.Update(c);
                Assert.IsTrue(isUpdate);
            }
            else {
                Assert.AreEqual("", "不存在历史记录");
            }
            
            //Models.Comment c = new Models.Comment() { Title = "test" };
            //bool result = DataHelper.Add<Models.Comment>(c);
            //Assert.IsTrue(result, "数据库添加失败");
        }

        [TestMethod]
        public void DeleteTest()
        {
            var result = DataHelper.QueryAll<Models.Comment>();
            Assert.IsTrue(result != null && result.Count >= 0);
            Models.Comment c = null;
            foreach (var item in result)
            {
                if (item.Author == "Update")
                {
                    c = item;
                    break;
                }
            }
            bool isdel = DataHelper.Delete<Models.Comment>(c.Id);
            Assert.IsTrue(isdel, "删除失败");
        }


    }
}
