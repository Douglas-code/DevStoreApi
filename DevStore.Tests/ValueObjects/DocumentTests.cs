using DevStore.Domain.StoreContext.ValueObjects;
using Xunit;

namespace DevStore.Tests.ValueObjects
{
    public class DocumentTests
    {
        private Document _validDocument;
        private Document _invalidDocument;

        public DocumentTests()
        {
            this._invalidDocument = new Document("111111111111");
            this._validDocument = new Document("01140839080");
        }

        [Fact]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.True(this._invalidDocument.Invalid);
            Assert.True(this._invalidDocument.Notifications.Count > 0);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.True(this._validDocument.Valid);
            Assert.True(this._validDocument.Notifications.Count == 0);
        }
    }
}
