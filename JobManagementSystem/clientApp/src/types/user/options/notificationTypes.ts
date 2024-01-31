

enum NotificationType{
    Success,
    Fail,
    Terminated,
    Finished,
    SuccessWithValue
}



interface NotificationBase{
    message:string,
    type:NotificationType
}


interface GenericNotification extends NotificationBase{
    value:any,
    description:string,
}
