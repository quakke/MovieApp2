1) Включен ли интернет программно не проверяю, в DataViewModel есть параметр bool isInternetAvailable - сделала так, чтобы "по-быстрее"

2) Есть несколько "плохих" моментов, отмеченных TODO - не разрешила их из-за нехватки времени

3) Характеристики, описывающие фильмы, поместила в StringBuilder. Realm, как оказалось, не работает с StringBuilder, поэтому описание частично теряется при сохранении (переписать модельку, опять же, было бы долго, поэтому пока оставила так).

P.S. перед выполнением задания не была знакома с Realm и с unit-тестами
