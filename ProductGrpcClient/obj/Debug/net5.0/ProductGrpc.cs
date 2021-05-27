// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: product.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ProductGrpc.Protos {
  public static partial class ProductProtoService
  {
    static readonly string __ServiceName = "ProductProtoService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::ProductGrpc.Protos.GetProductRequest> __Marshaller_GetProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.GetProductRequest.Parser));
    static readonly grpc::Marshaller<global::ProductGrpc.Protos.ProductModel> __Marshaller_ProductModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.ProductModel.Parser));
    static readonly grpc::Marshaller<global::ProductGrpc.Protos.GetAllProductsRequest> __Marshaller_GetAllProductsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.GetAllProductsRequest.Parser));
    static readonly grpc::Marshaller<global::ProductGrpc.Protos.AddProductRequest> __Marshaller_AddProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.AddProductRequest.Parser));
    static readonly grpc::Marshaller<global::ProductGrpc.Protos.UpdateProductRequest> __Marshaller_UpdateProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.UpdateProductRequest.Parser));
    static readonly grpc::Marshaller<global::ProductGrpc.Protos.DeleteProductRequest> __Marshaller_DeleteProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.DeleteProductRequest.Parser));
    static readonly grpc::Marshaller<global::ProductGrpc.Protos.DeleteProductResponse> __Marshaller_DeleteProductResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.DeleteProductResponse.Parser));
    static readonly grpc::Marshaller<global::ProductGrpc.Protos.InsertBulkProductResponse> __Marshaller_InsertBulkProductResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductGrpc.Protos.InsertBulkProductResponse.Parser));
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    static readonly grpc::Method<global::ProductGrpc.Protos.GetProductRequest, global::ProductGrpc.Protos.ProductModel> __Method_GetProduct = new grpc::Method<global::ProductGrpc.Protos.GetProductRequest, global::ProductGrpc.Protos.ProductModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProduct",
        __Marshaller_GetProductRequest,
        __Marshaller_ProductModel);

    static readonly grpc::Method<global::ProductGrpc.Protos.GetAllProductsRequest, global::ProductGrpc.Protos.ProductModel> __Method_GetAllProducts = new grpc::Method<global::ProductGrpc.Protos.GetAllProductsRequest, global::ProductGrpc.Protos.ProductModel>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAllProducts",
        __Marshaller_GetAllProductsRequest,
        __Marshaller_ProductModel);

    static readonly grpc::Method<global::ProductGrpc.Protos.AddProductRequest, global::ProductGrpc.Protos.ProductModel> __Method_AddProduct = new grpc::Method<global::ProductGrpc.Protos.AddProductRequest, global::ProductGrpc.Protos.ProductModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddProduct",
        __Marshaller_AddProductRequest,
        __Marshaller_ProductModel);

    static readonly grpc::Method<global::ProductGrpc.Protos.UpdateProductRequest, global::ProductGrpc.Protos.ProductModel> __Method_UpdateProduct = new grpc::Method<global::ProductGrpc.Protos.UpdateProductRequest, global::ProductGrpc.Protos.ProductModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateProduct",
        __Marshaller_UpdateProductRequest,
        __Marshaller_ProductModel);

    static readonly grpc::Method<global::ProductGrpc.Protos.DeleteProductRequest, global::ProductGrpc.Protos.DeleteProductResponse> __Method_DeleteProduct = new grpc::Method<global::ProductGrpc.Protos.DeleteProductRequest, global::ProductGrpc.Protos.DeleteProductResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteProduct",
        __Marshaller_DeleteProductRequest,
        __Marshaller_DeleteProductResponse);

    static readonly grpc::Method<global::ProductGrpc.Protos.ProductModel, global::ProductGrpc.Protos.InsertBulkProductResponse> __Method_InsertBulkProduct = new grpc::Method<global::ProductGrpc.Protos.ProductModel, global::ProductGrpc.Protos.InsertBulkProductResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "InsertBulkProduct",
        __Marshaller_ProductModel,
        __Marshaller_InsertBulkProductResponse);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Test = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Test",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ProductGrpc.Protos.ProductReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ProductProtoService</summary>
    public partial class ProductProtoServiceClient : grpc::ClientBase<ProductProtoServiceClient>
    {
      /// <summary>Creates a new client for ProductProtoService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ProductProtoServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ProductProtoService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ProductProtoServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ProductProtoServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ProductProtoServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::ProductGrpc.Protos.ProductModel GetProduct(global::ProductGrpc.Protos.GetProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetProduct(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::ProductGrpc.Protos.ProductModel GetProduct(global::ProductGrpc.Protos.GetProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetProduct, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.ProductModel> GetProductAsync(global::ProductGrpc.Protos.GetProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetProductAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.ProductModel> GetProductAsync(global::ProductGrpc.Protos.GetProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetProduct, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::ProductGrpc.Protos.ProductModel> GetAllProducts(global::ProductGrpc.Protos.GetAllProductsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllProducts(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::ProductGrpc.Protos.ProductModel> GetAllProducts(global::ProductGrpc.Protos.GetAllProductsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetAllProducts, null, options, request);
      }
      public virtual global::ProductGrpc.Protos.ProductModel AddProduct(global::ProductGrpc.Protos.AddProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddProduct(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::ProductGrpc.Protos.ProductModel AddProduct(global::ProductGrpc.Protos.AddProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddProduct, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.ProductModel> AddProductAsync(global::ProductGrpc.Protos.AddProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddProductAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.ProductModel> AddProductAsync(global::ProductGrpc.Protos.AddProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddProduct, null, options, request);
      }
      public virtual global::ProductGrpc.Protos.ProductModel UpdateProduct(global::ProductGrpc.Protos.UpdateProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateProduct(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::ProductGrpc.Protos.ProductModel UpdateProduct(global::ProductGrpc.Protos.UpdateProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateProduct, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.ProductModel> UpdateProductAsync(global::ProductGrpc.Protos.UpdateProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateProductAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.ProductModel> UpdateProductAsync(global::ProductGrpc.Protos.UpdateProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateProduct, null, options, request);
      }
      public virtual global::ProductGrpc.Protos.DeleteProductResponse DeleteProduct(global::ProductGrpc.Protos.DeleteProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteProduct(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::ProductGrpc.Protos.DeleteProductResponse DeleteProduct(global::ProductGrpc.Protos.DeleteProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteProduct, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.DeleteProductResponse> DeleteProductAsync(global::ProductGrpc.Protos.DeleteProductRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteProductAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::ProductGrpc.Protos.DeleteProductResponse> DeleteProductAsync(global::ProductGrpc.Protos.DeleteProductRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteProduct, null, options, request);
      }
      public virtual grpc::AsyncClientStreamingCall<global::ProductGrpc.Protos.ProductModel, global::ProductGrpc.Protos.InsertBulkProductResponse> InsertBulkProduct(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return InsertBulkProduct(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncClientStreamingCall<global::ProductGrpc.Protos.ProductModel, global::ProductGrpc.Protos.InsertBulkProductResponse> InsertBulkProduct(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_InsertBulkProduct, null, options);
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty Test(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Test(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty Test(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Test, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> TestAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return TestAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> TestAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Test, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ProductProtoServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ProductProtoServiceClient(configuration);
      }
    }

  }
}
#endregion
