using Interview.Controllers.SomeEntityApi;
using Interview.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Interview.Tests.Controllers
{
    [TestClass]
    public class SomeEntityControllerTest
    {
        [TestMethod]
        public async Task GetAll()
        {
            var container = DependencyResolution.IoC.Initialize();

            var controller = container.GetInstance<SomeEntityController>();

            var allItems = (OkNegotiatedContentResult<IEnumerable<SomeEntityApiModel>>)await controller.Get();

            Assert.IsTrue(allItems.Content.Any());
        }

        [TestMethod]
        public async Task GetOne()
        {
            var container = DependencyResolution.IoC.Initialize();

            var controller = container.GetInstance<SomeEntityController>();

            var allItems = (OkNegotiatedContentResult<IEnumerable<SomeEntityApiModel>>)await controller.Get();

            Assert.IsTrue(allItems.Content.Any());

            var oneItem = (OkNegotiatedContentResult<SomeEntityApiModel>)await controller.Get(allItems.Content.First().Id);

            Assert.IsNotNull(oneItem.Content);
            Assert.IsTrue(oneItem.Content.Id == allItems.Content.First().Id);

            var notFound = await controller.Get(Guid.NewGuid());

            Assert.IsTrue(notFound is System.Web.Http.Results.NotFoundResult);
        }

        [TestMethod]
        public async Task PostPutAndDelete()
        {
            var container = DependencyResolution.IoC.Initialize();

            var controller = container.GetInstance<SomeEntityController>();

            var createModel = new CreateSomeEntityApiModel()
            {
                ApplicationId = 123456,
            };

            var createdItem = (OkNegotiatedContentResult<SomeEntityApiModel>)await controller.Post(createModel);

            Assert.IsTrue(createdItem.Content.Id != Guid.Empty);
            Assert.IsTrue(createdItem.Content.ApplicationId == createModel.ApplicationId);

            var updateModel = new UpdateSomeEntityApiModel
            {
                ApplicationId = createdItem.Content.ApplicationId,
                Type = "asdfasdf",
                Amount = 123.123m
            };

            await controller.Put(createdItem.Content.Id, updateModel);

            var updatedItem = (OkNegotiatedContentResult<SomeEntityApiModel>)await controller.Get(createdItem.Content.Id);

            Assert.IsTrue(createdItem.Content.Id == updatedItem.Content.Id);
            Assert.IsTrue(updateModel.ApplicationId == updatedItem.Content.ApplicationId);
            Assert.IsTrue(updateModel.Type == updatedItem.Content.Type);
            Assert.IsTrue(updateModel.Amount == updatedItem.Content.Amount);

            var deleteResult = await controller.Delete(createdItem.Content.Id);

            var notFound = await controller.Get(createdItem.Content.Id);

            Assert.IsTrue(notFound is NotFoundResult);
        }

        [TestMethod]
        public async Task MultyGetAll()
        {
            var container = DependencyResolution.IoC.Initialize();

            var controller = container.GetInstance<SomeEntityController>();

            var result = await Task.WhenAll(controller.Get(), controller.Get(), controller.Get(), controller.Get(), controller.Get());

            Assert.IsTrue(result.All(x => x is OkNegotiatedContentResult<IEnumerable<SomeEntityApiModel>>));
        }
    }

}
