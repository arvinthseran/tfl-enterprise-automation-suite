namespace ConfigurationBuilder
{
    [Binding]
    public class TestDataAttachmentHooks
    {
        private readonly ObjectContext _objectContext;

        public TestDataAttachmentHooks(ScenarioContext context) => _objectContext = context.Get<ObjectContext>();

        [AfterScenario(Order = 99)]
        public void AfterScenario_AttachTestData() => TestAttachmentHelper.AddTestDataAttachment(_objectContext.GetDirectory(), _objectContext.GetAll());
    }
}