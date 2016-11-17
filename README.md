###QBdd mini framework

QBdd provides support to simplify some repeating patterns in testing SOLID-like code.
It uses NUnit and RhinoMocks.

####Features

* Support for wrapping context of an instance and its references. Instead of

```C#
var barMock = MockRepository.GenerateMock<IBar>();
var fuzzMock = MockRepository.GenerateMock<IFuzz>();

barMock.Stub(x => x.BarFunction()).Return(1);

var underTest = new Foo(barMock, fuzzMock);

var result = underTest.FooMethod();
```

you can write

```C#
var fooContext = Mockery.Create<Foo>();
fooContext.Stub<IBar>(x => x.BarFunction()).Return(1);

var result = fooContext.UnderTest.FooMethod();
```

* BDD style for NUnit:

```C#
public class When_FooMethod : BddTestsBase<Foo>
{
    private int _result;

    protected override void Given()
    {
        Context.Stub<IBar>(x => x.BarFunction()).Return(1);
    }

    protected override void When()
    {
        _result = Context.UnderTest.FooMethod();
    }

    [Then]
    public void ItShouldReturnExpected()
    {
        Assert.AreEqual(1, _result);
    }

    [Then]
    public void ItShouldCallFuzzMethod()
    {
        Context.AssertWasCalled<IFuzz>(x => x.FuzzMethod(Arg<int>.Is.Anything));
    }
}
```
