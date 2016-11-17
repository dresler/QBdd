The repository contains a foundation of very simple BDD framework. It tries to simplify some repeating patterns.
It uses NUnit and RhinoMocks.

* Support for wrapping context of an instance and its references. Instead of

```C#
var barMock = MockRepository.GenerateMock<IBar>();
var fuzzMock = MockRepository.GenerateMock<IFuzz>();

barMock.Stub(x => x.BarFunction()).Return(1);

var underTest = new Foo(barMock, fuzzMock);

var result = underTest.FooMethod();

Assert.AreEqual(1, result);
```

you can write

```C#
var mockedFoo = Mockery.Create<Foo>();
mockedFoo.Stub<IBar>(x => x.BarFunction()).Return(1);

var result = mockedFoo.UnderTest.FooMethod();

Assert.AreEqual(1, result);
```
