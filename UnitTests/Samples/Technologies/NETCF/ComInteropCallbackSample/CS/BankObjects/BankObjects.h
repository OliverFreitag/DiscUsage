/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 5.01.0164 */
/* at Thu Dec 02 16:05:54 2004
 */
/* Compiler settings for .\BankObjects.idl:
    Oicf (OptLev=i2), W1, Zp8, env=Win32, ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
*/
//@@MIDL_FILE_HEADING(  )


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __BankObjects_h__
#define __BankObjects_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __IAccountCallback_FWD_DEFINED__
#define __IAccountCallback_FWD_DEFINED__
typedef interface IAccountCallback IAccountCallback;
#endif 	/* __IAccountCallback_FWD_DEFINED__ */


#ifndef __IAccount_FWD_DEFINED__
#define __IAccount_FWD_DEFINED__
typedef interface IAccount IAccount;
#endif 	/* __IAccount_FWD_DEFINED__ */


#ifndef __Account_FWD_DEFINED__
#define __Account_FWD_DEFINED__

#ifdef __cplusplus
typedef class Account Account;
#else
typedef struct Account Account;
#endif /* __cplusplus */

#endif 	/* __Account_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

#ifndef __IAccountCallback_INTERFACE_DEFINED__
#define __IAccountCallback_INTERFACE_DEFINED__

/* interface IAccountCallback */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IAccountCallback;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B140E6B6-20A0-46f5-8942-5EF7B6BC3647")
    IAccountCallback : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE BalanceChanged( 
            /* [in] */ int newBalance) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAccountCallbackVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAccountCallback __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAccountCallback __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAccountCallback __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            IAccountCallback __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            IAccountCallback __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            IAccountCallback __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            IAccountCallback __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *BalanceChanged )( 
            IAccountCallback __RPC_FAR * This,
            /* [in] */ int newBalance);
        
        END_INTERFACE
    } IAccountCallbackVtbl;

    interface IAccountCallback
    {
        CONST_VTBL struct IAccountCallbackVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAccountCallback_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAccountCallback_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAccountCallback_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAccountCallback_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IAccountCallback_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IAccountCallback_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IAccountCallback_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IAccountCallback_BalanceChanged(This,newBalance)	\
    (This)->lpVtbl -> BalanceChanged(This,newBalance)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IAccountCallback_BalanceChanged_Proxy( 
    IAccountCallback __RPC_FAR * This,
    /* [in] */ int newBalance);


void __RPC_STUB IAccountCallback_BalanceChanged_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAccountCallback_INTERFACE_DEFINED__ */


#ifndef __IAccount_INTERFACE_DEFINED__
#define __IAccount_INTERFACE_DEFINED__

/* interface IAccount */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IAccount;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E1D08CB7-CE32-4B52-931C-4FFC52D48BC4")
    IAccount : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Initialize( 
            /* [in] */ int initialBalance,
            /* [in] */ IAccountCallback __RPC_FAR *callbackInterface) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Deposit( 
            /* [in] */ int amount) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Withdraw( 
            /* [in] */ int amount) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAccountVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAccount __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAccount __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAccount __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            IAccount __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            IAccount __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            IAccount __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            IAccount __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IAccount __RPC_FAR * This,
            /* [in] */ int initialBalance,
            /* [in] */ IAccountCallback __RPC_FAR *callbackInterface);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Deposit )( 
            IAccount __RPC_FAR * This,
            /* [in] */ int amount);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Withdraw )( 
            IAccount __RPC_FAR * This,
            /* [in] */ int amount);
        
        END_INTERFACE
    } IAccountVtbl;

    interface IAccount
    {
        CONST_VTBL struct IAccountVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAccount_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAccount_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAccount_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAccount_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IAccount_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IAccount_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IAccount_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IAccount_Initialize(This,initialBalance,callbackInterface)	\
    (This)->lpVtbl -> Initialize(This,initialBalance,callbackInterface)

#define IAccount_Deposit(This,amount)	\
    (This)->lpVtbl -> Deposit(This,amount)

#define IAccount_Withdraw(This,amount)	\
    (This)->lpVtbl -> Withdraw(This,amount)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IAccount_Initialize_Proxy( 
    IAccount __RPC_FAR * This,
    /* [in] */ int initialBalance,
    /* [in] */ IAccountCallback __RPC_FAR *callbackInterface);


void __RPC_STUB IAccount_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAccount_Deposit_Proxy( 
    IAccount __RPC_FAR * This,
    /* [in] */ int amount);


void __RPC_STUB IAccount_Deposit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IAccount_Withdraw_Proxy( 
    IAccount __RPC_FAR * This,
    /* [in] */ int amount);


void __RPC_STUB IAccount_Withdraw_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAccount_INTERFACE_DEFINED__ */



#ifndef __BankObjectsLib_LIBRARY_DEFINED__
#define __BankObjectsLib_LIBRARY_DEFINED__

/* library BankObjectsLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_BankObjectsLib;

EXTERN_C const CLSID CLSID_Account;

#ifdef __cplusplus

class DECLSPEC_UUID("B45E7F99-F50E-4F77-8FEC-F3906082FE0C")
Account;
#endif
#endif /* __BankObjectsLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
