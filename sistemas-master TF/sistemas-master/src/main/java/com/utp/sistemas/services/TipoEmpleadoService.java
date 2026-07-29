package com.utp.sistemas.services;

import com.utp.sistemas.entities.TipoEmpleado;
import com.utp.sistemas.repositories.TipoEmpleadoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class TipoEmpleadoService {

    @Autowired
    private TipoEmpleadoRepository tipoEmpleadoRepository;

    public TipoEmpleado createTipoEmpleado(TipoEmpleado tipoEmpleado) {
        return tipoEmpleadoRepository.save(tipoEmpleado);
    }

    public List<TipoEmpleado> getAllTipoEmpleados() {
        return tipoEmpleadoRepository.findAll();
    }

    public Optional<TipoEmpleado> getTipoEmpleadoById(Integer id) {
        return tipoEmpleadoRepository.findById(id);
    }

    public TipoEmpleado updateTipoEmpleado(Integer id, TipoEmpleado tipoEmpleadoDetails) {
        Optional<TipoEmpleado> tipoEmpleado = tipoEmpleadoRepository.findById(id);
        if (tipoEmpleado.isPresent()) {
            TipoEmpleado updatedTipoEmpleado = tipoEmpleado.get();
            updatedTipoEmpleado.setDescripcion(tipoEmpleadoDetails.getDescripcion());
            updatedTipoEmpleado.setEstado(tipoEmpleadoDetails.getEstado());
            return tipoEmpleadoRepository.save(updatedTipoEmpleado);
        }
        return null;
    }

    public void deleteTipoEmpleado(Integer id) {
        Optional<TipoEmpleado> tipoEmpleado = tipoEmpleadoRepository.findById(id);
        tipoEmpleado.ifPresent(t -> tipoEmpleadoRepository.delete(t));
    }
}