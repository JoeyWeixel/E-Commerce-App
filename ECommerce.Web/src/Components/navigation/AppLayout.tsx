import { Outlet } from 'react-router-dom'
import Header from './Header'

const AppLayout = () => {
    return (
        <div className="flex flex-col w-screen items-start">
            <Header />
            <Outlet />
        </div>
    )
}

export default AppLayout