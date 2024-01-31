

enum NotificationType{
    Success,
    Fail,
    Terminated,
    Finished,
    SuccessWithValue
}



interface NotificationBase{
    description:string,
    type:NotificationType
}


interface GenericNotification extends NotificationBase{
    value:any,
    message:string,
}
